using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserImages;
public class UserImageUpdateRequest
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
}
