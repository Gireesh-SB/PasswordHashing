# Password Hashing

## DESCRIPTION
### Creating a new user
1. Generate a random encrypted string as Salt
2. Append the Salt to the Password
3. Generate a Hash from the combined string
4. Store the Hash and Salt to the database. Do not store the password.

### Authenticating a user
1. Fetch the Hash and Salt of that particular user
2. Append the Salt to the input password
3. Generate a new Hash from the combined string
4. Compare the new Hash with existing Hash. If matched, then password is same and user is authenticated.

## FRAMEWORK
.NET Core
## Language
C#
