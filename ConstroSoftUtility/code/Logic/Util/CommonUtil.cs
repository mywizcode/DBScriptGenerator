
/// <summary>
/// Summary description for CommonUtil
/// </summary>
using ConstroSoft;
using System.Collections.Generic;
using NHibernate.Criterion;
using System.Linq.Expressions;
using NHibernate.Impl;
using System;
namespace ConstroSoft
{
    public class CommonUtil
    {
        public CommonUtil() { }
        public static bool hasEntitlement(UserDefinitionDTO userDefDto, string entitlement)
        {
            return userDefDto != null && userDefDto.UserRole.entitlements != null && userDefDto.UserRole.entitlements.Contains(entitlement);
        }

        public static MasterControlDataDTO getMasterControlDTO(string Id)
        {
            MasterControlDataDTO mdDto = null;
            if (!string.IsNullOrWhiteSpace(Id))
            {
                mdDto = new MasterControlDataDTO();
                mdDto.Id = long.Parse(Id);
            }
            return mdDto;
        }
        public static DepartmentDTO getDepartmentDTO(string Id)
        {
            DepartmentDTO dto = null;
            if (!string.IsNullOrWhiteSpace(Id))
            {
                dto = new DepartmentDTO();
                dto.Id = long.Parse(Id);
            }
            return dto;
        }
        public static MasterControlDataDTO populateMasterDataDTOAdd(string type, string name, string description, UserDefinitionDTO userDefDto)
        {
            MasterControlDataDTO masterDataDto = new MasterControlDataDTO();
            masterDataDto.Name = name;
            masterDataDto.Description = description;
            masterDataDto.FirmNumber = userDefDto.FirmNumber;
            masterDataDto.InsertUser = userDefDto.Username;
            masterDataDto.UpdateUser = userDefDto.Username;
            masterDataDto.Type = type;
            masterDataDto.SystemDefined = "N";
            return masterDataDto;
        }
        public static DepartmentDTO populateDepartmentDTOAdd(string name, string description, UserDefinitionDTO userDefDto)
        {
            DepartmentDTO departmentDto = new DepartmentDTO();
            departmentDto.Name = name;
            departmentDto.Description = description;
            departmentDto.FirmNumber = userDefDto.FirmNumber;
            departmentDto.InsertUser = userDefDto.Username;
            departmentDto.UpdateUser = userDefDto.Username;
            return departmentDto;
        }
        public static PropertyProjection BuildProjection<T>(Expression<Func<object>> aliasExpression, Expression<Func<T, object>> propertyExpression)
        {
            string alias = ExpressionProcessor.FindMemberExpression(aliasExpression.Body);
            string property = ExpressionProcessor.FindMemberExpression(propertyExpression.Body);

            return Projections.Property(string.Format("{0}.{1}", alias, property));
        }
    }
}