import React, { useState, useEffect } from 'react';
import { useParams } from "react-router-dom";

import RecipeList from '../components/RecipeList';
import IngredientList from '../components/IngredientList';

import Button from '../components/Button';
import Textbox from '../components/Textbox';

import { getRecipesAPI, addRecipeAPI, updateRecipeAPI, deleteRecipeAPI} from '../api/Recipe';

const Recipe = (props) => {
    let params = useParams();
   
    const [currentRecipes, setRecipes] = useState([]);
    const [recipeId, setRecipeId] = useState([]);
    const [recipeName, setRecipeName] = useState('');
    const [addRecipeName, setAddRecipeName] = useState([]);
    const [editRecipeName, setEditRecipeName] = useState('');

    useEffect(() => { 
        async function fetchData() {
            var newRecipes = [];
                var recipes = await getRecipesAPI(params.userId);
                for (var i = 0; i < recipes.length; i++)
                {        
                    newRecipes.push(
                        {
                            id : recipes[i].id,
                            name : recipes[i].name,
                            userId : recipes[i].userId,
                            editMode : false
                        }
                    );
                }
                setRecipes( newRecipes );
        }
        fetchData();
    }, [params.userId])

    function setRecipe( id, name ) {
        setRecipeId( id );
        setRecipeName( name )
    }

    async function addRecipe() {
        if (addRecipeName != null)
        {
            var response = await addRecipeAPI( { name: addRecipeName, userId: Number(params.userId) } );
            currentRecipes.push(
                {
                    id : response.id,
                    name : response.name,
                    userId : response.userId,
                    editMode : false
                } );
            setAddRecipeName('');
            setRecipe(response.id);
            setRecipes(currentRecipes);
        }      
    }

    function setEditRecipe( id ) {
        for (var i = 0; i < currentRecipes.length; i++)
        {  
            if (currentRecipes[i].id === id)
            {
                currentRecipes[i].editMode = true;
                setEditRecipeName(currentRecipes[i].name)
            }
            else {
                currentRecipes[i].editMode = false;
            }
        }
        setRecipes( currentRecipes );
    }

    async function editRecipe( id ) {
        if (id != null)
        {
            await updateRecipeAPI( id, { id: id, name: editRecipeName, userId: Number(params.userId) } );
            for (var i = 0; i < currentRecipes.length; i++)
            {  
                if (currentRecipes[i].id === id)
                {
                    currentRecipes[i].name = editRecipeName;
                }
                currentRecipes[i].editMode = false;
            }
        setEditRecipeName('');
        setRecipes( currentRecipes );
        }
    }

    async function removeRecipe( id ) {
        if (id != null)
        {
            await deleteRecipeAPI( id );
            setRecipes(currentRecipes.filter(item => item.id !== id));
        }
    }

    return (
        <> 
            <div className="recipes-list">
                <RecipeList itemList={ currentRecipes } 
                    onSelect={ setRecipe } 
                    onSelectEdit={ setEditRecipe }
                    setEditName={ setEditRecipeName }
                    editName={ editRecipeName }
                    onEdit={ editRecipe } 
                    onDelete={ removeRecipe } />
                <div className="add-item">
                    <Textbox name='Name:' value={ addRecipeName } setValue={ setAddRecipeName } />
                    <Button name='Add' setAction={ addRecipe } />
                </div>

            </div>

            <IngredientList recipeId={ recipeId } recipeName = { recipeName } />         
        </>);
  };
  
  export default Recipe;