/* eslint-disable react/prop-types */
import { useEffect, useState } from 'react';
import { GetForm, PostFormData } from '../../../service/FormsService';
import Field from './field';
import { Button, Form } from 'reactstrap';

const DynamicForm = ({ currentForm }) => {
    const [formFields, setFormFields] = useState([]);
    const [formData, setFormData] = useState({});

    useEffect(() => {
        const fetchFormFields = async () => {
            const form = await GetForm(currentForm.id);
            if (form && form.length > 0) {
                setFormFields(form.data.fields); // Assuming the form structure has a 'fields' property
            }
        };

        fetchFormFields();
    }, [currentForm.id]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await PostFormData(formData);
            console.log('Form submitted successfully:', response);
        } catch (error) {
            console.error('Error submitting form:', error);
        }
    };

    return (
        <Form onSubmit={handleSubmit}>
            {formFields.map((field, index) => (
                <Field
                    key={index}
                    type={field.type}
                    name={field.name}
                    onChange={handleChange}
                />
            ))}
            <Button type="submit" color="primary">Submit</Button>
        </Form>
    );
};

export default DynamicForm;