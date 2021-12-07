export function getIngredientsAPI(recipeId) {
    return fetch('http://localhost:36440/api/ingredient/recipe/' + recipeId)
      .then(data => data.json())
}

export function addIngredientAPI(ingredient) {
   return fetch('http://localhost:36440/api/ingredient/', {
     method: 'POST',
     headers: {
       'Content-Type': 'application/json'
     },
     body: JSON.stringify(ingredient)
   })
     .then(data => data.json())
}

export function updateIngredientAPI(ingredientId, ingredient) {
    return fetch('http://localhost:36440/api/ingredient/' + ingredientId, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(ingredient)
    })
      .then(data => data.status)
 }

 export function deleteIngredientAPI(ingredientId) {
    return fetch('http://localhost:36440/api/ingredient/' + ingredientId, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(data => data.status)
 }