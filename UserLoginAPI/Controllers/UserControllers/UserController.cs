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

    [HttpGet("Registration")]
    public ActionResult<UserNuanceResponse> RegistrationNaunce()
    {
        int Nuance = _APImanager.GenerateNuance();
        return new UserNuanceResponse(Nuance);
    }

    [HttpPost("Registration/send")]
    public IActionResult Registration(UserAccessRequest userToRegister)
    {
        User newUser = new User(
            userToRegister.Name,
            userToRegister.Surname,
            userToRegister.Email,
            userToRegister.NickName
        );


        if (_APImanager.InsertNewUser(newUser, userToRegister.NuanceCodifiedPassword))
        {
            return Created($"/{newUser.Email}", null);
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
    public ActionResult<UserLoginResponse> UserLogin(UserAccessRequest user)
    {
        User userToValidate = new User(
            user.Name,
            user.Surname,
            user.Email,
            user.NickName
        );

        UserLoginResponse? validationToken = new(_APImanager.validate(userToValidate, user.NuanceCodifiedPassword));
        return validationToken == null ? NotFound() : validationToken;
    }
}