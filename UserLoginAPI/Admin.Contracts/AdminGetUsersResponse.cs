public record AdminUser(
    string NickName,
    string Email
);

public record AdminGetUsersResponse(
    AdminUser[] users
);
