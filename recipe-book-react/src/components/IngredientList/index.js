import React, { useState, useEffect } from 'react';
import IngredientItem from './IngredientItem';

import Button from '../Button';
import Textbox from '../Textbox';

import { getIngredientsAPI, addIngredientAPI, updateIngredientAPI, deleteIngredientAPI} from '../../api/Ingredient';

export default function IngredientList(props) {

    const [currentIngredients, setIngredients] = useState([]);
    const [addIngredientName, setAddIngredientName] = useState('');
    const [editIngredientName, setEditIngredientName] = useState('');

    useEffect( () => {
        async function fetchData() {
            var newIngredients = [];
            var ingredients = await getIngredientsAPI(props.recipeId);
            for (var i = 0; i < ingredients.length; i++)
            {        
                newIngredients.push(
                    {
                        id : ingredients[i].id,
                        name : ingredients[i].name,
                        recipeId : ingredients[i].recipeId,
                        obtained: ingredients[i].obtained,
                        editMode : false
                    }
                );
            }
            setIngredients( newIngredients );
        }
        fetchData();
    }, [props.recipeId])

    async function addIngredient() {
        if (addIngredientName != null)
        {
            var response = await addIngredientAPI( { name: addIngredientName, recipeId: Number(props.recipeId), obtained: false } );
            currentIngredients.push(
                {
                    id : response.id,
                    name : response.name,
                    recipeId : response.recipeId,
                    obtained: response.obtained,
                    editMode : false
                } );
            setAddIngredientName('');
            setIngredients(currentIngredients); 
        }      
    }

    function setEditIngredient( id ) {
        for (var i = 0; i < currentIngredients.length; i++)
        {  
            if (currentIngredients[i].id === id)
            {
                currentIngredients[i].editMode = true;
                setEditIngredientName(currentIngredients[i].name)
            }
            else {
                currentIngredients[i].editMode = false;
            }
        }
        setIngredients( currentIngredients );
    }

    async function editIngredient( id, obtained ) {
        if (id != null)
        {
            await updateIngredientAPI( id, { id: id, name: editIngredientName, recipeId: Number(props.recipeId), obtained: obtained } );
            for (var i = 0; i < currentIngredients.length; i++)
            {  
                if (currentIngredients[i].id === id)
                {
                    currentIngredients[i].name = editIngredientName;
                }
                currentIngredients[i].editMode = false;
            }
        setEditIngredientName('');
        setIngredients( currentIngredients );
        }
    }

    async function removeIngredient( id ) {
        if (id != null)
        {
            await deleteIngredientAPI( id );
            setIngredients(currentIngredients.filter(item => item.id !== id));
        }
    }

    async function toggleIngredient(id) {
        for (var i = 0; i < currentIngredients.length; i++)
            {  
                if (currentIngredients[i].id === id)
                {
                    currentIngredients[i].obtained = !currentIngredients[i].obtained;
                    await updateIngredientAPI( id, {   
                                id: currentIngredients[i].id, 
                                name: currentIngredients[i].name, 
                                recipeId: currentIngredients[i].recipeId, 
                                obtained: currentIngredients[i].obtained 
                            } 
                        );
                }
            }
        setIngredients(currentIngredients);
    }

    if (currentIngredients.length === 0)
    {
        return (
            <>
                <div className="ingredients-list">
                    <div className="ingredient-item">
                        {props.recipeName}
                    </div>
                    <span> No Ingredients. </span>

                    <br />
                    <div className="add-item">
                        <Textbox name='Name:' value={ addIngredientName } setValue={ setAddIngredientName } />
                        <Button name='Add' setAction={ addIngredient } />
                    </div>
                </div>
            </>
        );
    }
    else {
        return (
            <>
                <div className="ingredients-list">
                        <div className="ingredient-item">
                            {props.recipeName}
                        </div>
                        { currentIngredients.map(o =>
                            <div className="ingredient-item">
                                <IngredientItem ingredient={ o } 
                                        markEditIngredient={ setEditIngredient } 
                                        deleteIngredient={ removeIngredient } 
                                        setEditName={ setEditIngredientName }
                                        editName={ editIngredientName }
                                        editIngredient={ editIngredient }
                                        toggleIngredient = { toggleIngredient }
                                        setIngredients={ setIngredients } />
                            </div> 
                        )}

                    <br />
                    <div className="add-item">
                        <Textbox name='Name:' value={ addIngredientName } setValue={ setAddIngredientName } />
                        <Button name='Add' setAction={ addIngredient } />
                    </div>
                </div>
            </>
        );
    }
}