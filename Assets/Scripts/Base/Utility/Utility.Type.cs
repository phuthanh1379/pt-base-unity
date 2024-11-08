using System;
using System.Collections.Generic;
using System.Reflection;

namespace Base.Utility
{
    public static partial class Utility
    {
        private static readonly MemberFilter _delegateToSearchCriteria = DelegateToSearchCriteria;

        private static bool DelegateToSearchCriteria(MemberInfo objMemberInfo, object objSearch)
        {
            return objMemberInfo.IsDefined((Type)objSearch, true);
        }

        public static List<MemberInfo> GetInjectProperties(Type type, Type attributeType)
        {
            if (type == null || type == typeof(object) || !type.IsClass || type.IsInterface)
            {
                return null;
            }

            var memberInfoList = new List<MemberInfo>();
            var baseTypeMembers = GetInjectProperties(type.BaseType, attributeType);
            if (baseTypeMembers != null)
            {
                memberInfoList.AddRange(baseTypeMembers);
            }

            var memberInfos = type.FindMembers(MemberTypes.Property,
                BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                _delegateToSearchCriteria, attributeType);

            memberInfoList.AddRange(memberInfos);
            return memberInfoList;
        }
    }
}