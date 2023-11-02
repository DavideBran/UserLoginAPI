public class User
{
    private string _name;
    private string _surname;
    private string _email;
    private string _nickName;


    public string Name { get => _name; }
    public string Surname { get => _surname; }
    public string Email { get => _email; }
    public string NickName { get => _nickName; }


    public User(string name, string surname, string email, string nickName)
    {
        _name = name; 
        _surname = surname; 
        _email = email;
        _nickName = nickName;
    }

}