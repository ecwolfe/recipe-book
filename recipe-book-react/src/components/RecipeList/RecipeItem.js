import Button from '../Button';
import Textbox from '../Textbox';

export default function RecipeItem(props) {
    if (!props.recipe.editMode)
    {
        return (
                <div key={'recipe-key-' + props.recipe.id}>
                    <span> {props.recipe.name}</span>
                    <div className='btn-item'>
                        <Button name='Edit' setAction={ () => props.markEditRecipe(props.recipe.id) } />
                        <Button name='Delete' setAction={ () => props.deleteRecipe(props.recipe.id)  } />
                    </div>
                </div>
            );
    }
    else{
        return (
            <div key='recipe-key-add'>
                <Textbox name='' value={ props.editName } setValue={ props.setEditName } />
                <div className='btn-item'>
                    <Button name='Save' setAction={ () => props.editRecipe(props.recipe.id) } />
                </div>
            </div>
        );
    }

}