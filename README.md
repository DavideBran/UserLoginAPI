## Login API

- [User Request](#User)
  - [New Registration](#Register-New-User)
  - [Get User by Email](#Get-User-By-Email)
  - [Login](#Login)
- [Admin Request](#Admin)
  - [Remove User](#Remove-User)
  - [Get All Users](#Get-All-Users)
- [Program request](#Program-Request)
  - [Validate User](#Validate-User)

# User

- ## Register New User

  ```js
      GET registration

  --------------------------------------

      POST registration

      body:
          `{
              Name: "Name",
              Surname: "Surname",
              NickName: "NickName",
              Email: "Email",
              NuanceCodifiedPassword: "xxxxxxxx"
          }`
  ```

  - ### Registration Response

    ```js
        GET registration

            {
                "Nuance": 13
            }

        POST registration

        201 Created
    ```

- ## Get User by Email

  ```js
      GET login/{{email}}
  ```

  - ### User Response

    ```json
        {
            "Nuance": 12
        }

        or

        404 NotFound
    ```

- ## Login

  ```js
      POST login

      body: 
           `{
                "NuanceCodifiedPassword": "xxxxxxx"
            }`
  ```

  - ### Login Response

    ```json
        {
            "ValidationToken": "xxxxx"
        }

        or

        404 NotFound
    ```

# Admin

- ## Remove User

  ```js
      DELETE Admin/remove/{{id}}
  ```

  - ### Remove Response

    ```json
        204 NoContent
    ```

- ## Get All User

  ```js
      GET Admin/getAll
  ```

  - ### Response
    ```json
    {
      "Users": [
        { "Nickname": "nickName", "Email": "Email" },
        { "Nickname": "nickName", "Email": "Email" },
        { "Nickname": "nickName", "Email": "Email" }
      ]
    }
    ```

# Program

- ## Validate User

  ```js
      POST program/Validate

      body:
          {
              Token: "xxxxxx"
          }
  ```

  - ### Validate Response

    ```js
        202 Accepted

        or

        401 Unauthorized

    ```
