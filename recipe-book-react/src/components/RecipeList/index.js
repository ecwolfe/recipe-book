import React from 'react';
import RecipeItem from './RecipeItem';

export default function RecipeList(props) {
    if (props.itemList.length === 0)
    {
        return (
            <>
                <div>
                    <span> No Recipes. </span>
                </div>
            </>
        );
    }
    else {
        return (
            <>
                <div>
                    { props.itemList.map(o =>
                        <div className="recipe-item">
                            <div onClick={ () => props.onSelect( o.id, o.name ) }>
                                <RecipeItem recipe={ o } 
                                    markEditRecipe={ props.onSelectEdit } 
                                    deleteRecipe={ props.onDelete } 
                                    setEditName={ props.setEditName }
                                    editName={ props.editName }
                                    editRecipe={ props.onEdit } />
                            </div>
                        </div>
                    )}
                </div>
            </>
        );
    }
}

