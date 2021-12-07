import Button from '../Button';
import Textbox from '../Textbox';
import Checkbox from '../Checkbox';

export default function IngredientItem(props) {
    if (!props.ingredient.editMode)
    {
        return (
                <>
                    <Checkbox 
                        name={props.ingredient.name} 
                        checked={props.ingredient.obtained} 
                        label={props.ingredient.name} 
                        onChange={props.toggleIngredient}
                        id={props.ingredient.id}
                    />
                    <div className='btn-item'>
                        <Button name='Edit' setAction={ () => props.markEditIngredient(props.ingredient.id) } />
                        <Button name='Delete' setAction={ () => props.deleteIngredient(props.ingredient.id)  } />
                    </div>
                </>
            );
    }
    else{
        return (
            <>
                <Textbox name='' value={ props.editName } setValue={ props.setEditName } />
                <div className='btn-item'>
                    <Button name='Save' setAction={ () => props.editIngredient(props.ingredient.id, props.ingredient.obtained) } />
                </div>
            </>
        );
    }

}