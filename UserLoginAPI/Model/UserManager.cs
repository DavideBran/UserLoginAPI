public class UserManager
{
    private Random _nuanceGenerator;
    private int _lastNuance;

    private List<string> _tokens;

    // key: User Email // Value: User Password (with the corrispective nuance)
    private Dictionary<string, string> _usersWithPassword;

    public UserManager()
    {
        _nuanceGenerator = new Random();
        _tokens = new();
        _usersWithPassword = new();
    }


    public bool InsertNewUser(User userToRegister, string password)
    {
        if (_usersWithPassword.ContainsKey(userToRegister.Email)) { return false; }
        //save into file the new user with the corrispective nuance
        //save(userToregister, __lastNuance)
        _usersWithPassword.Add(userToRegister.Email, password);
        return true;
    }

    public UserResponse? GetUserByEmail(string email)
    {
        return null;
    }

    public int GenerateNuance()
    {
        _lastNuance = _nuanceGenerator.Next();
        return _lastNuance;
    }

    public User Validate(string userEmail, string passwordToValidate)
    {
        return new User("test", "test", "testEmail", "testNIck");
    }

    public string GenerateToken(User user) { return "testToken"; }
}