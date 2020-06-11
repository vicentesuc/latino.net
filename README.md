# EVOLVE  - .NET CORE

This project was generated with 

* .NET CORE 3.1
* KESTREL 

* POSTGRES SQL.

## Database migrations 
 * EVOLVE 2.4

All sql files are located into resources/db 

## Development server
Run Kestrel Server  for a dev/Prod with SSL server. Navigate to `https://localhost/50001/rest`. 

## IDE Divelopment

RIDER 2020.1 from Intelij

## DATABASE NAME
   * use videogames     

## Build
To run automatically  , use the next steps.


## Running unit tests
This project dont use testing by the moment

## Run with docker

This project  needs a environments to work , the environments must be configured in docker-compose.

if not exist this environemnts you can't  connect to database and the project crash

* POSTGRES_USER: admin
* POSTGRES_PASSWORD: admin
* POSTGRES_DB: videogames


