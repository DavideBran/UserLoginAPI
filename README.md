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
      POST User/Registration

      body:
          `{
              Name: "Name",
              Surname: "Surname",
              NickName: "NickName",
              Email: "Email",
              HashedPassword: "xxxxxxxx"
          }`
  ```

  - ### Registration Response

    ```js

        POST registration

        201 Created
        
        or
        
         400 BadRequest
    ```

- ## Get User by Email

  ```js
      GET User/Login/{{email}}
  ```

  ```js
      GET User/{{email}}
  ```
  - ### User Response

    ```json
        (login)
        
        {
            "Nuance": 12
        }

        or 

        404 NotFound

        (get)

        200 Ok

        or

        404 NotFound
    ```

- ## Login

  ```js
      POST User/Login

      body: 
           `{
                "Email" : "Email@email.com"
                "NuanceCodifiedPassword": "xxxxxxx"
            }`
  ```

  - ### Login Response

    ```json
        {
            "Name" : "name"
            "Surname" : "surname"
            "Email" : "email" 
            "NickName" : "nickName"
            "ValidationToken": "xxxxx"
        }

        or

        404 NotFound
    ```

# Admin

- ## Remove User

  ```js
      DELETE Admin/Remove/{{id}}
  ```

  - ### Remove Response

    ```json
        204 NoContent
    ```

- ## Get All User

  ```js
      GET Admin
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
