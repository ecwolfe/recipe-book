export function getRecipesAPI(userId) {
    return fetch('http://localhost:36440/api/recipe/user/' + userId)
      .then(data => data.json())
}

export function addRecipeAPI(recipe) {
   return fetch('http://localhost:36440/api/recipe/', {
     method: 'POST',
     headers: {
       'Content-Type': 'application/json'
     },
     body: JSON.stringify(recipe)
   })
     .then(data => data.json())
}

export function updateRecipeAPI(recipeId, recipe) {
    return fetch('http://localhost:36440/api/recipe/' + recipeId, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(recipe)
    })
      .then(data => data.status)
 }

 export function deleteRecipeAPI(recipeId) {
    return fetch('http://localhost:36440/api/recipe/' + recipeId, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(data => data.status)
 }