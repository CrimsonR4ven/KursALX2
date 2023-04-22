using System;
using System.Collections.Generic;

namespace D5_MySqlWebApi.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedTimeStamp { get; set; }
}
