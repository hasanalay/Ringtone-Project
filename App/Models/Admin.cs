using System.Collections.Generic;

namespace App.Models;
public class Admin
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> Permissions { get; set; }
}