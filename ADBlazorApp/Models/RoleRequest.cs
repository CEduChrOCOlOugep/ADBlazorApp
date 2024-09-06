namespace ADBlazorApp.Models;

public class RoleRequest
{
    public string UserName { get; set; } = string.Empty;
    public string RequestedRole { get; set; } = string.Empty;
    public DateTime RequestedAt { get; set; } = DateTime.Now;
    public bool IsApproved { get; set; } = false;
    public bool IsDenied { get; set; } = false;
}