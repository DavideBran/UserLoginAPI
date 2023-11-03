public record UserLoginResponse(
    string Name, 
    string Surname, 
    string Email, 
    string NickName,
    string ValidationToken
);