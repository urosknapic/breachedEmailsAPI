# breachedEmailsAPI

## Redis on docker
Get redis ready before running application
- docker pull redis
- docker run --name breachedEmailsRedis -p 5002:6379 -d redis

## API
- written in c# asp.net core
- open with VS2022 editor and start localy. 
- url of local (development) is https://localhost:7095
- Swager Documentation: https://localhost:7095/swagger/index.html

After running redis server on docker, and running solution, go ahead and test it using postman. Template of postman was added to project name by BreachedAPI.postman_collection.json
