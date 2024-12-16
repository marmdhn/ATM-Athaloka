﻿namespace ATMBank_.Models;

public class User
{
    public int id { get; set; }

    public string? username { get; set; }

    public string? password { get; set; }

    public int role { get; set; }

    public Customer? customer { get; set; }
    public Admin? admin { get; set; }
}
