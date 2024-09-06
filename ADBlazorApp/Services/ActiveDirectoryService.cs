#if WINDOWS
using System.DirectoryServices.AccountManagement;

public class ActiveDirectoryService
{
    private readonly string _domain;

    public ActiveDirectoryService(string domain = "your_domain")
    {
        _domain = domain;
    }

    public IEnumerable<string> GetAllRoles()
    {
        using (var context = new PrincipalContext(ContextType.Domain, _domain))
        {
            GroupPrincipal group = new GroupPrincipal(context);
            PrincipalSearcher searcher = new PrincipalSearcher(group);
            var roles = new List<string>();

            foreach (var result in searcher.FindAll())
            {
                roles.Add(result.Name);
            }

            return roles;
        }
    }

    public IEnumerable<string> GetUserRoles(string username)
    {
        using (var context = new PrincipalContext(ContextType.Domain, _domain))
        {
            using (var user = UserPrincipal.FindByIdentity(context, username))
            {
                if (user != null)
                {
                    var roles = new List<string>();
                    var groups = user.GetAuthorizationGroups();

                    foreach (var group in groups)
                    {
                        roles.Add(group.Name);
                    }

                    return roles;
                }
                else
                {
                    throw new Exception($"User {username} not found in Active Directory.");
                }
            }
        }
    }
}
#else
public class ActiveDirectoryService
{
    public IEnumerable<string> GetAllRoles()
    {
        return new List<string> { "MockRole1", "MockRole2" };
    }

    public IEnumerable<string> GetUserRoles(string username)
    {
        return new List<string> { "MockRole" };
    }
}
#endif