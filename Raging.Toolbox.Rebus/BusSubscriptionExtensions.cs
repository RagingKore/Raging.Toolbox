using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Raging.Toolbox.Extensions;
using Rebus;

namespace Tru.Common.Rebus
{
    public static class BusSubscriptionExtensions
    {
        public static Type[] ReferencedTypes = AppDomain.CurrentDomain.GetReferencedTypes().ToArray();

        private static readonly MethodInfo BusSubscribeMethod = typeof(IBus).GetMethod("Subscribe");

        public static void SubscribeMessagesAssignableFrom(this IBus bus, Type messageBaseType, Func<string, bool> namespaceFilter = null)
        {
            var messages = GetMessages(t => t != messageBaseType 
                && messageBaseType.IsAssignableFrom(t) 
                && (namespaceFilter == null || namespaceFilter(t.Namespace)));

            foreach (var message in messages)
                bus.SubscribeMessage(message);
        }

        public static void SubscribeMessagesAssignableFrom<TBaseType>(this IBus bus, Func<string, bool> namespaceFilter = null)
        {
            bus.SubscribeMessagesAssignableFrom(typeof(TBaseType), namespaceFilter);
        }

        public static void SubscribeMessages(this IBus bus, Func<Type, bool> typeFilter)
        {
            foreach (var message in GetMessages(typeFilter))
                bus.SubscribeMessage(message);
        }

        public static void SubscribeMessage<TMessage>(this IBus bus)
            where TMessage : class
        {
            bus.SubscribeMessage(typeof(TMessage));
        }

        private static void SubscribeMessage(this IBus bus, Type messageType)
        {
            try
            {
                BusSubscribeMethod
                    .MakeGenericMethod(messageType)
                    .Invoke(bus, new object[] { });
            }
            catch (Exception)
            {
                // type is not subscribable
            }
        }

        private static IEnumerable<Type> GetMessages(Func<Type, bool> typeFilter = null)
        {
            var messageTypes = ReferencedTypes
                .SelectMany(t => t.GetInterfaces())
                .Where(i => i.IsGenericType && (
                    i.GetGenericTypeDefinition() == typeof(IHandleMessages<>) || 
                    i.GetGenericTypeDefinition() == typeof(IHandleMessagesAsync<>)))
                .Select(t => t.GetGenericArguments()[0])
                .Where(t => t.Namespace != null && !t.Namespace.StartsWith("Rebus"));

            return typeFilter != null ? messageTypes.Where(typeFilter) : messageTypes;
        }
    }
}