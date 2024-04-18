namespace SharpApi.Repository;

public class UserRepository(DataContext context) : BaseRepository<User, DataContext>(context)
{
    
}