using System.Collections.Generic;

namespace Common.DataStructures
{
    public static class ObjectExtensions
    {
        private static readonly IList<object> ProcessedList;
        private static readonly IDictionary<object, object> ExtraProperties;

        static ObjectExtensions()
        {
            ProcessedList = new List<object>();
            ExtraProperties = new Dictionary<object, object>();
        }
        public static void SetProcessed(this object extended)
        {
            ProcessedList.Add(extended);
        }

        public static bool IsProcessed(this object extended)
        {
            return ProcessedList.Contains(extended);
        }

        public static void SetProperty<T>(this object extended, T property)
        {
            ExtraProperties[extended] = property;
        }

        public static T GetProperty<T>(this object extended)
        {
            return (T) ExtraProperties[extended];
        }
    }
}
