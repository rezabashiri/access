﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccessManagementService.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
      using System.Data.Entity.Core.Objects;
        using System.Data.Entity.Core.Objects.DataClasses;
    using System.Linq;
    
    public partial class AccessEntities : DbContext
    {
        public AccessEntities()
            : base("name=AccessEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<OrganiztionRole> OrganiztionRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
    
        public virtual int DoLogin(Nullable<int> userId, string iPLocation, string sessionId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var iPLocationParameter = iPLocation != null ?
                new ObjectParameter("IPLocation", iPLocation) :
                new ObjectParameter("IPLocation", typeof(string));
    
            var sessionIdParameter = sessionId != null ?
                new ObjectParameter("SessionId", sessionId) :
                new ObjectParameter("SessionId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DoLogin", userIdParameter, iPLocationParameter, sessionIdParameter);
        }
    
        public virtual int DoLogout(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DoLogout", userIdParameter);
        }
    
        public virtual ObjectResult<GetRoleGroup_Result> GetRoleGroup(Nullable<int> roleId)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRoleGroup_Result>("GetRoleGroup", roleIdParameter);
        }
    
        public virtual int GetRolesOfUser(Nullable<int> userId, Nullable<bool> isActive, ObjectParameter rolesIds)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetRolesOfUser", userIdParameter, isActiveParameter, rolesIds);
        }
    
        public virtual ObjectResult<Role> ListRolesOfUser(Nullable<int> userId, Nullable<bool> isActive)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Role>("ListRolesOfUser", userIdParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<Role> ListRolesOfUser(Nullable<int> userId, Nullable<bool> isActive, MergeOption mergeOption)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Role>("ListRolesOfUser", mergeOption, userIdParameter, isActiveParameter);
        }
    
        public virtual int LoginCheck(string userName, string password, ObjectParameter returnValue)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LoginCheck", userNameParameter, passwordParameter, returnValue);
        }
    
        public virtual ObjectResult<Entity> Right_EntityGet(Nullable<int> roleId, string relatedService)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var relatedServiceParameter = relatedService != null ?
                new ObjectParameter("RelatedService", relatedService) :
                new ObjectParameter("RelatedService", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Entity>("Right_EntityGet", roleIdParameter, relatedServiceParameter);
        }
    
        public virtual ObjectResult<Entity> Right_EntityGet(Nullable<int> roleId, string relatedService, MergeOption mergeOption)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var relatedServiceParameter = relatedService != null ?
                new ObjectParameter("RelatedService", relatedService) :
                new ObjectParameter("RelatedService", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Entity>("Right_EntityGet", mergeOption, roleIdParameter, relatedServiceParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Right_EntityValidRole(Nullable<int> roleId, string relatedService, string entityName)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var relatedServiceParameter = relatedService != null ?
                new ObjectParameter("RelatedService", relatedService) :
                new ObjectParameter("RelatedService", typeof(string));
    
            var entityNameParameter = entityName != null ?
                new ObjectParameter("EntityName", entityName) :
                new ObjectParameter("EntityName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Right_EntityValidRole", roleIdParameter, relatedServiceParameter, entityNameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Right_EntityValidRoles(string rolesIDs, string relatedService, string entityName)
        {
            var rolesIDsParameter = rolesIDs != null ?
                new ObjectParameter("RolesIDs", rolesIDs) :
                new ObjectParameter("RolesIDs", typeof(string));
    
            var relatedServiceParameter = relatedService != null ?
                new ObjectParameter("RelatedService", relatedService) :
                new ObjectParameter("RelatedService", typeof(string));
    
            var entityNameParameter = entityName != null ?
                new ObjectParameter("EntityName", entityName) :
                new ObjectParameter("EntityName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Right_EntityValidRoles", rolesIDsParameter, relatedServiceParameter, entityNameParameter);
        }
    
        public virtual ObjectResult<Right> Right_Get(Nullable<int> roleId, Nullable<int> rightType, string rightName, string relatedService, Nullable<int> organizationRoleId, Nullable<int> entityId)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var rightTypeParameter = rightType.HasValue ?
                new ObjectParameter("RightType", rightType) :
                new ObjectParameter("RightType", typeof(int));
    
            var rightNameParameter = rightName != null ?
                new ObjectParameter("RightName", rightName) :
                new ObjectParameter("RightName", typeof(string));
    
            var relatedServiceParameter = relatedService != null ?
                new ObjectParameter("RelatedService", relatedService) :
                new ObjectParameter("RelatedService", typeof(string));
    
            var organizationRoleIdParameter = organizationRoleId.HasValue ?
                new ObjectParameter("OrganizationRoleId", organizationRoleId) :
                new ObjectParameter("OrganizationRoleId", typeof(int));
    
            var entityIdParameter = entityId.HasValue ?
                new ObjectParameter("EntityId", entityId) :
                new ObjectParameter("EntityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Right>("Right_Get", roleIdParameter, rightTypeParameter, rightNameParameter, relatedServiceParameter, organizationRoleIdParameter, entityIdParameter);
        }
    
        public virtual ObjectResult<Right> Right_Get(Nullable<int> roleId, Nullable<int> rightType, string rightName, string relatedService, Nullable<int> organizationRoleId, Nullable<int> entityId, MergeOption mergeOption)
        {
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(int));
    
            var rightTypeParameter = rightType.HasValue ?
                new ObjectParameter("RightType", rightType) :
                new ObjectParameter("RightType", typeof(int));
    
            var rightNameParameter = rightName != null ?
                new ObjectParameter("RightName", rightName) :
                new ObjectParameter("RightName", typeof(string));
    
            var relatedServiceParameter = relatedService != null ?
                new ObjectParameter("RelatedService", relatedService) :
                new ObjectParameter("RelatedService", typeof(string));
    
            var organizationRoleIdParameter = organizationRoleId.HasValue ?
                new ObjectParameter("OrganizationRoleId", organizationRoleId) :
                new ObjectParameter("OrganizationRoleId", typeof(int));
    
            var entityIdParameter = entityId.HasValue ?
                new ObjectParameter("EntityId", entityId) :
                new ObjectParameter("EntityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Right>("Right_Get", mergeOption, roleIdParameter, rightTypeParameter, rightNameParameter, relatedServiceParameter, organizationRoleIdParameter, entityIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Right_ValidByName(string roleIDs, string rightName)
        {
            var roleIDsParameter = roleIDs != null ?
                new ObjectParameter("RoleIDs", roleIDs) :
                new ObjectParameter("RoleIDs", typeof(string));
    
            var rightNameParameter = rightName != null ?
                new ObjectParameter("RightName", rightName) :
                new ObjectParameter("RightName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Right_ValidByName", roleIDsParameter, rightNameParameter);
        }
    
        public virtual int SetOrganizationRoleParrentID(Nullable<int> iD, Nullable<int> parrentID)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var parrentIDParameter = parrentID.HasValue ?
                new ObjectParameter("ParrentID", parrentID) :
                new ObjectParameter("ParrentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetOrganizationRoleParrentID", iDParameter, parrentIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> Right_ValidByServiceName(string roleIDs, string serviceName)
        {
            var roleIDsParameter = roleIDs != null ?
                new ObjectParameter("RoleIDs", roleIDs) :
                new ObjectParameter("RoleIDs", typeof(string));
    
            var serviceNameParameter = serviceName != null ?
                new ObjectParameter("ServiceName", serviceName) :
                new ObjectParameter("ServiceName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Right_ValidByServiceName", roleIDsParameter, serviceNameParameter);
        }
    
        public virtual ObjectResult<Department> ListDeparmentsOfUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Department>("ListDeparmentsOfUser", userIDParameter);
        }
    
        public virtual ObjectResult<Department> ListDeparmentsOfUser(Nullable<int> userID, MergeOption mergeOption)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Department>("ListDeparmentsOfUser", mergeOption, userIDParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertDepartment(string departmentName, string phones, string faxes, string adress, string emailAdress, string deparetmentChartXML, string logoPath, Nullable<bool> isNeerdToConfirm, Nullable<bool> isNeedConfirmToChangePassword, Nullable<bool> isVisible, string seeting)
        {
            var departmentNameParameter = departmentName != null ?
                new ObjectParameter("DepartmentName", departmentName) :
                new ObjectParameter("DepartmentName", typeof(string));
    
            var phonesParameter = phones != null ?
                new ObjectParameter("Phones", phones) :
                new ObjectParameter("Phones", typeof(string));
    
            var faxesParameter = faxes != null ?
                new ObjectParameter("Faxes", faxes) :
                new ObjectParameter("Faxes", typeof(string));
    
            var adressParameter = adress != null ?
                new ObjectParameter("Adress", adress) :
                new ObjectParameter("Adress", typeof(string));
    
            var emailAdressParameter = emailAdress != null ?
                new ObjectParameter("EmailAdress", emailAdress) :
                new ObjectParameter("EmailAdress", typeof(string));
    
            var deparetmentChartXMLParameter = deparetmentChartXML != null ?
                new ObjectParameter("DeparetmentChartXML", deparetmentChartXML) :
                new ObjectParameter("DeparetmentChartXML", typeof(string));
    
            var logoPathParameter = logoPath != null ?
                new ObjectParameter("LogoPath", logoPath) :
                new ObjectParameter("LogoPath", typeof(string));
    
            var isNeerdToConfirmParameter = isNeerdToConfirm.HasValue ?
                new ObjectParameter("IsNeerdToConfirm", isNeerdToConfirm) :
                new ObjectParameter("IsNeerdToConfirm", typeof(bool));
    
            var isNeedConfirmToChangePasswordParameter = isNeedConfirmToChangePassword.HasValue ?
                new ObjectParameter("IsNeedConfirmToChangePassword", isNeedConfirmToChangePassword) :
                new ObjectParameter("IsNeedConfirmToChangePassword", typeof(bool));
    
            var isVisibleParameter = isVisible.HasValue ?
                new ObjectParameter("IsVisible", isVisible) :
                new ObjectParameter("IsVisible", typeof(bool));
    
            var seetingParameter = seeting != null ?
                new ObjectParameter("seeting", seeting) :
                new ObjectParameter("seeting", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertDepartment", departmentNameParameter, phonesParameter, faxesParameter, adressParameter, emailAdressParameter, deparetmentChartXMLParameter, logoPathParameter, isNeerdToConfirmParameter, isNeedConfirmToChangePasswordParameter, isVisibleParameter, seetingParameter);
        }
    
        public virtual ObjectResult<sp_signup_insert_Result> sp_signup_insert(string firstName, string lastName, string userName, string password, string newPassword, Nullable<bool> isActive, Nullable<bool> isOnline, Nullable<bool> isConfirm, Nullable<System.DateTime> lastLoginTime, Nullable<bool> gender, Nullable<bool> marriedStatus, Nullable<System.DateTime> birthDate, Nullable<short> countryNo, Nullable<byte> languageNo, string address, string e_Mail, string photoPath, Nullable<System.DateTime> creationDate, Nullable<System.DateTime> editionDate, Nullable<System.DateTime> lastRefreshTime, Nullable<System.DateTime> lastChangePassDate, string nativeID, string personnelID, string activeSessionID, string systemProfile, string iPLocation, Nullable<int> departmentID, string phone, string mobile)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var newPasswordParameter = newPassword != null ?
                new ObjectParameter("NewPassword", newPassword) :
                new ObjectParameter("NewPassword", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var isOnlineParameter = isOnline.HasValue ?
                new ObjectParameter("IsOnline", isOnline) :
                new ObjectParameter("IsOnline", typeof(bool));
    
            var isConfirmParameter = isConfirm.HasValue ?
                new ObjectParameter("IsConfirm", isConfirm) :
                new ObjectParameter("IsConfirm", typeof(bool));
    
            var lastLoginTimeParameter = lastLoginTime.HasValue ?
                new ObjectParameter("LastLoginTime", lastLoginTime) :
                new ObjectParameter("LastLoginTime", typeof(System.DateTime));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(bool));
    
            var marriedStatusParameter = marriedStatus.HasValue ?
                new ObjectParameter("MarriedStatus", marriedStatus) :
                new ObjectParameter("MarriedStatus", typeof(bool));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var countryNoParameter = countryNo.HasValue ?
                new ObjectParameter("CountryNo", countryNo) :
                new ObjectParameter("CountryNo", typeof(short));
    
            var languageNoParameter = languageNo.HasValue ?
                new ObjectParameter("LanguageNo", languageNo) :
                new ObjectParameter("LanguageNo", typeof(byte));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var e_MailParameter = e_Mail != null ?
                new ObjectParameter("E_Mail", e_Mail) :
                new ObjectParameter("E_Mail", typeof(string));
    
            var photoPathParameter = photoPath != null ?
                new ObjectParameter("PhotoPath", photoPath) :
                new ObjectParameter("PhotoPath", typeof(string));
    
            var creationDateParameter = creationDate.HasValue ?
                new ObjectParameter("CreationDate", creationDate) :
                new ObjectParameter("CreationDate", typeof(System.DateTime));
    
            var editionDateParameter = editionDate.HasValue ?
                new ObjectParameter("EditionDate", editionDate) :
                new ObjectParameter("EditionDate", typeof(System.DateTime));
    
            var lastRefreshTimeParameter = lastRefreshTime.HasValue ?
                new ObjectParameter("LastRefreshTime", lastRefreshTime) :
                new ObjectParameter("LastRefreshTime", typeof(System.DateTime));
    
            var lastChangePassDateParameter = lastChangePassDate.HasValue ?
                new ObjectParameter("LastChangePassDate", lastChangePassDate) :
                new ObjectParameter("LastChangePassDate", typeof(System.DateTime));
    
            var nativeIDParameter = nativeID != null ?
                new ObjectParameter("NativeID", nativeID) :
                new ObjectParameter("NativeID", typeof(string));
    
            var personnelIDParameter = personnelID != null ?
                new ObjectParameter("PersonnelID", personnelID) :
                new ObjectParameter("PersonnelID", typeof(string));
    
            var activeSessionIDParameter = activeSessionID != null ?
                new ObjectParameter("ActiveSessionID", activeSessionID) :
                new ObjectParameter("ActiveSessionID", typeof(string));
    
            var systemProfileParameter = systemProfile != null ?
                new ObjectParameter("SystemProfile", systemProfile) :
                new ObjectParameter("SystemProfile", typeof(string));
    
            var iPLocationParameter = iPLocation != null ?
                new ObjectParameter("IPLocation", iPLocation) :
                new ObjectParameter("IPLocation", typeof(string));
    
            var departmentIDParameter = departmentID.HasValue ?
                new ObjectParameter("DepartmentID", departmentID) :
                new ObjectParameter("DepartmentID", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_signup_insert_Result>("sp_signup_insert", firstNameParameter, lastNameParameter, userNameParameter, passwordParameter, newPasswordParameter, isActiveParameter, isOnlineParameter, isConfirmParameter, lastLoginTimeParameter, genderParameter, marriedStatusParameter, birthDateParameter, countryNoParameter, languageNoParameter, addressParameter, e_MailParameter, photoPathParameter, creationDateParameter, editionDateParameter, lastRefreshTimeParameter, lastChangePassDateParameter, nativeIDParameter, personnelIDParameter, activeSessionIDParameter, systemProfileParameter, iPLocationParameter, departmentIDParameter, phoneParameter, mobileParameter);
        }
    
        public virtual int sp_active_User(Nullable<bool> isActive, Nullable<int> iD)
        {
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_active_User", isActiveParameter, iDParameter);
        }
    
        public virtual int SpActiveUserByUserName(string userName, Nullable<bool> isActive)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SpActiveUserByUserName", userNameParameter, isActiveParameter);
        }
    }
}
