using Pagination.Models;

namespace Pagination;

public interface IUserService
{
   public void AddUsers(Users users);
    
   public List<Users> GetUsers();
}