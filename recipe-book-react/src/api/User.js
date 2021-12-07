
export async function getUserById(userId) {
   return await fetch('http://localhost:36440/api/user/' + userId)
     .then(data => data.json())
}

export async function getUserAPI(user) {
    var reponse = await fetch('http://localhost:36440/api/user/name/' + user);
    var data = await reponse.json();
    return data;
}
  
export async function addUserAPI(user) {
   return await fetch('http://localhost:36440/api/user/', {
     method: 'POST',
     headers: {
       'Content-Type': 'application/json'
     },
     body: JSON.stringify(user)
   })
     .then(data => data.json())
}