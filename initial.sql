use Abyari
go

declare @depname nvarchar(50)
declare @depid int,@orgid int,@userid int,@rightid int,@roleid int



set @depname='انجمن پیمانکاران'
INSERT INTO [TakhteFoolad].[asc].[Department]([DepartmentName])values(@depname)
select @depid=@@IDENTITY
INSERT INTO [asc].[Right]
           ([RightName]
           ,[RelatedService]
           ,[RightType]
   )
     VALUES
           (N'مجوز ورود به سیستم'
           ,N'سرویس تشخیص هویت'
           ,0)
          select @rightid=@@IDENTITY
insert into [asc].[User] ([FirstName]
      ,[LastName]
      ,[UserName]
      ,[Password]
      ,[IsActive]
      ,[IsOnline]
      ,[IsConfirm]) values(N'رضا',N'بشیری','rz','svkLRj9nYEgZo7gWDJD5IQ==',1,0,1)
      select @userid=@@IDENTITY
insert into [asc].OrganiztionRole (OrganizationRoleName) values (N'مدیر سیستم')
select @depid=@@IDENTITY
insert into [asc].[Role](OrganizationRoleID,UserID,IsActive,RoleName) values(@orgid,@userid,1,'مدیرسیستم')
select @orgid=@@IDENTITY
INSERT INTO  [asc].[Roles_Rights]
           ([RoleID]
           ,[RightID])
     VALUES
           (@roleid
           ,@rightid)
           print('init success')
GO


      