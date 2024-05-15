using DemoJWT.Models;

namespace DemoJWT.Data.Entities;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
}