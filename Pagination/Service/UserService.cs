using Pagination.Common;
using Pagination.Models;

namespace Pagination;

public class UserService : IUserService
{
    private readonly REPODB _repoDB;

    public UserService(REPODB repoDB)
    {
        _repoDB = repoDB;
    }
    public void AddUsers(Users user)
    {
        _repoDB.Users.Add(user);
        _repoDB.SaveChanges();
    }

    public List<Users> GetUsers()
    {
        return _repoDB.Users.ToList();
    }
}