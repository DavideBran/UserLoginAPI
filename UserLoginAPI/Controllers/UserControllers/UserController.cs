using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private UserManager _APImanager;

    public UserController(UserManager userManager)
    {
        _APImanager = userManager;
    }

    [HttpPost("Registration")]
    public ActionResult<UserRegistrationResponse> Registration(UserRegistrationRequest userToRegister)
    {
        User newUser = new User(
            userToRegister.Name,
            userToRegister.Surname,
            userToRegister.Email,
            userToRegister.NickName
        );


        if (_APImanager.InsertNewUser(newUser, userToRegister.HashedPassword))
        {
            return new UserRegistrationResponse(_APImanager.GenerateToken(newUser));
        }

        return BadRequest();
    }

    [HttpGet("{email}")]
    public IActionResult GetUser(string email)
    {
        UserResponse? userGetted = _APImanager.GetUserByEmail(email);
        return userGetted == null ? NotFound() : Ok(userGetted);
    }

    [HttpGet("Login/{email}")]
    public ActionResult<UserNuanceResponse> GetUserForLogin(string email)
    {
        UserResponse? userGetted = _APImanager.GetUserByEmail(email);
        return userGetted == null ? NotFound() : new UserNuanceResponse(_APImanager.GenerateNuance());
    }

    [HttpPost("Login")]
    public ActionResult<UserLoginResponse> UserLogin(UserLoginRequest user)
    {
        string userEmail = user.Email;
        User validateUser = _APImanager.Validate(userEmail, user.NuanceCodifiedPassword);
        if (validateUser == null) return NotFound();
        return new UserLoginResponse(
             validateUser.Name,
             validateUser.Surname,
             validateUser.Email,
             validateUser.NickName,
             _APImanager.GenerateToken(validateUser)
         );
    }
}