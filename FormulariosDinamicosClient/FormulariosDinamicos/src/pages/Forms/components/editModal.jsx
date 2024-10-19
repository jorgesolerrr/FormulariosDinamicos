/* eslint-disable react/prop-types */
import { useState, useEffect } from 'react';
import { Modal, ModalHeader, ModalBody, Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { GetForm } from '../../../service/FormsService';

const EditModal = ({ isOpen, toggle, currentForm, onSave }) => {
    const [formFields, setFormFields] = useState([]);

    useEffect(() => {
        const fetchFormFields = async () => {
            const form = await GetForm(currentForm.id);
            setFormFields(form.data.fields); // Assuming the form structure has a 'fields' property
            
        };

        fetchFormFields();
    }, [currentForm.id]);

    const handleChange = (index, event) => {
        const newFields = [...formFields];
        newFields[index][event.target.name] = event.target.value;
        setFormFields(newFields);
    };

    const handleSave = () => {
        onSave(formFields);
        toggle();
    };

    return (
        <Modal isOpen={isOpen} toggle={toggle} centered style={{display: 'flex', alignItems:'center', justifyContent : 'center', minHeight: '100vh'}}>
            <ModalHeader toggle={toggle}>Edit Form</ModalHeader>
            <ModalBody>
                <Form>
                    {formFields.map((field, index) => (
                        <FormGroup key={index} style={{ marginBottom: '1.5rem' }}>
                            <div style={{ display: 'flex', flexDirection: 'column' }}>
                                <Label for={`field-name-${index}`}>Field Name</Label>
                                <Input
                                    type="text"
                                    name="name"
                                    id={`field-name-${index}`}
                                    value={field.name}
                                    onChange={(e) => handleChange(index, e)}
                                />
                            </div>
                            <div style={{ display: 'flex', flexDirection: 'column' }}>
                                <Label for={`field-type-${index}`}>Field Type</Label>
                                <Input
                                    type="select"
                                    name="type"
                                    id={`field-type-${index}`}
                                    value={field.type.name}
                                    onChange={(e) => handleChange(index, e)}
                                />
                            </div>
                        </FormGroup>
                    ))}
                    <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '1rem' }}>
                        <Button color="primary" onClick={handleSave}>Save</Button>
                        <Button color="secondary" onClick={toggle}>Cancel</Button>
                    </div>
                </Form>
            </ModalBody>
        </Modal>
    );
};


export default EditModal;