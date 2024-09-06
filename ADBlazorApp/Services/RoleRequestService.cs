using ADBlazorApp.Models;

namespace ADBlazorApp.Services;

public class RoleRequestService
{
    private readonly List<RoleRequest> _requests = new();

    // Add a new role request
    public void AddRequest(string userName, string role)
    {
        // Add logic to create a new RoleRequest and add it to the database or in-memory list
        Console.WriteLine($"Request added for user {userName} for role {role}");
    }

    // Retrieve pending requests (requests that are neither approved nor denied)
    public IEnumerable<RoleRequest> GetPendingRequests()
    {
        return _requests.Where(r => !r.IsApproved && !r.IsDenied);
    }

    // Approve a role request
    public void ApproveRequest(RoleRequest request)
    {
        var req = _requests.FirstOrDefault(r =>
            r.UserName == request.UserName && r.RequestedRole == request.RequestedRole);
        if (req != null) req.IsApproved = true;
        // Additional logic to assign the role to the user
    }

    // Deny a role request
    public void DenyRequest(RoleRequest request)
    {
        var req = _requests.FirstOrDefault(r =>
            r.UserName == request.UserName && r.RequestedRole == request.RequestedRole);
        if (req != null) req.IsDenied = true;
    }

    // Logic to assign the role to the user (stubbed)
    private void AssignRoleToUser(string userName, string role)
    {
        // Add logic to interact with Active Directory or another system to assign the role
        Console.WriteLine($"Assigning role {role} to user {userName}");
    }
}