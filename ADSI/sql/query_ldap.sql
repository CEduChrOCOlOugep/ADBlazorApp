SELECT [Name],
       [SN],
       [GivenName],
       [Mail],
       [sAMAccountName]
FROM
    OPENQUERY(ADSI,
              'SELECT Name, SN, GivenName, Mail, sAMAccountName 
               FROM ''LDAP://DC=yourdomain,DC=com'' 
               WHERE objectClass = ''User''');
