
import { Input, Label, FormGroup } from 'reactstrap';

// eslint-disable-next-line react/prop-types
const Field = ({ type, name }) => {
    return (
        <FormGroup style={{display : 'flex', flexDirection : 'column', alignItems : 'flex-start'}}>
            <Label for={name} >{name}</Label>
            <Input type={type} id={name} name={name} style={{ width: '100%', padding: '7px' }} />
        </FormGroup>
    );
};

export default Field;