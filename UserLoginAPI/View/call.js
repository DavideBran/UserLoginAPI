class InvalidUrlInserted extends Error { }
class InvalidProtocol extends Error { }
class BadRequestException extends Error { }

class User {
    Name;
    Surname;
    NickName;
    Email;

    constructor(name, surname, nickName, email) {
        this.Name = name;
        this.Surname = surname;
        this.NickName = nickName;
        this.Email = email;
    }
}


UserService = class {
    baseUrl;

    #passwordHash(password) {
        if (typeof (password) !== "string") { password = password.toString(); }
        let hashedPassword = "";
        for (let i = 0; i < password.length; i++) {
            hashedPassword += password.charCodeAt(i);
        }
        return hashedPassword;
    }

    async register(user, password) {
        const response = await fetch(`${this.baseUrl}User/Registration`);
        const nuanceJson = await response.json();
        const nuance = await nuanceJson.nuance;
        const userNuancedPassword = `${password}${nuance}`;

        let hashedPassword = this.#passwordHash(userNuancedPassword);

        const userWithPassword = {
            "Name": user.Name,
            "Surname": user.Surname,
            "NickName": user.NickName,
            "Email": user.Email,
            "NuanceCodifiedPassword": hashedPassword
        }

        const register = await fetch(
            `${this.baseUrl}User/Registration/send`,
            {
                method: "POST",
                body: JSON.stringify(userWithPassword),
                headers: {
                    "Content-Type": "application/json"
                },
            }
        )
        if (!register.ok) { throw new BadRequestException("BadRequest"); }
        else console.log(register.status + " User Registreted");
    }

    constructor(url) {
        if (!url) throw new InvalidProtocol("Invalid URL");
        if (typeof (url) == "string") {
            if (!url.endsWith("/")) url += "/";
            try {
                url = new URL(url);
            }
            catch (e) {
                throw new InvalidUrlInserted("Invalid URL");
            }
        }
        if (!url.protocol.startsWith("http")) throw new InvalidProtocol("Not HTTP protocol");
        this.baseUrl = url;
    }
}



try {
    const service = new UserService("http://localhost:5080");
    const userPassword = "testPassword1212";
    service.register(new User(
        "Davide",
        "Brancato",
        "Tha",
        "bdavide3@icloud.com"
    ), userPassword
    ).catch(
        (error) => console.log(error.message)
    );
}
catch (e) {
    console.error(e.message);
}