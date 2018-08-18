using System.Collections.Generic;
using Santex_Football.Application.Entities;

public class TeamRootObject
{
    public Links _links { get; set; }
    public int count { get; set; }
    public List<Team> teams { get; set; }
}