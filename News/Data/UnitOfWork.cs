using News.Data.Repositories;

namespace News.Data
{
    public class UnitOfWork
    {
        public RoleRepository Roles { get; set; }
        public UserRepository Users { get; set; }
        public UserRolesRepository UserRoles { get; set; }
        public UnitOfWork(
            UserRepository userRepository,
            RoleRepository roleRepasitory,
            UserRolesRepository userRolesRepasitory)
        {
            Roles = roleRepasitory;
            Users = userRepository;
            UserRoles = userRolesRepasitory;
        }


    }
}
