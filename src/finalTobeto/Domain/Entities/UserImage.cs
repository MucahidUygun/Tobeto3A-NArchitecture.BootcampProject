using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UserImage : Entity<int>
{
    public Guid UserId { get; set; }
    public string ImagePath { get; set; }
    public virtual User? User { get; set; }

    public UserImage()
    {

    }
    public UserImage(int id, Guid userId, string imagePath)
    {
        Id = id;
        UserId = userId;
        ImagePath = imagePath;
    }
}
