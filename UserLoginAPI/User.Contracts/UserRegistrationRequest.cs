public record UserRegistrationRequest(
    string Name,
    string Surname, 
    string NickName, 
    string Email,
    int NuancePasswordCodified
);