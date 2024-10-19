/* eslint-disable react/prop-types */
import { useEffect, useState } from "react";
import { GetForm, PostFormData } from "../../../service/FormsService";
import Field from "./field";
import { Button, Form } from "reactstrap";
import EditModal from "./editModal";

const DynamicForm = ({ currentForm }) => {
    const [formFields, setFormFields] = useState([]);
    const [formData, setFormData] = useState({});
    const [isEditModalOpen, setIsEditModalOpen] = useState(false);

    useEffect(() => {
        const fetchFormFields = async () => {
            const form = await GetForm(currentForm.id);
            console.log(form);
            console.log(form.data.fields);
            setFormFields(form.data.fields); // Assuming the form structure has a 'fields' property
        };

        fetchFormFields();
    }, [currentForm.id]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await PostFormData(formData);
            console.log("Form submitted successfully:", response);
        } catch (error) {
            console.error("Error submitting form:", error);
        }
    };

    const toggleEditModal = () => {
        setIsEditModalOpen(!isEditModalOpen);
    };

    const handleEditClick = () => {
        toggleEditModal();
    };

    return (
        <div
            style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                flexDirection: "column",
            }}
        >
            <h3>{currentForm.name}</h3>
            <Form onSubmit={handleSubmit} style={{ width: "100%" }}>
                {formFields.map((field, index) => (
                    <Field
                        key={index}
                        type={field.type.name}
                        name={field.name}
                        onChange={handleChange}
                    />
                ))}
                <div style={{ marginTop: "10px", textAlign: "center" }}>
                    <Button
                        type="submit"
                        color="primary"
                        style={{ marginRight: "10px" }}
                    >
                        Enviar
                    </Button>
                    <Button
                        color="primary"
                        style={{ marginRight: "10px" }}
                        onClick={handleEditClick}
                    >
                        Editar
                    </Button>
                    <Button color="primary" style={{ marginRight: "10px" }}>
                        Eliminar
                    </Button>
                    <Button color="primary">Datos</Button>
                </div>
            </Form>
            <div>
                <EditModal
                    isOpen={isEditModalOpen}
                    toggle={toggleEditModal}
                    currentForm={currentForm}
                    onSave={(updatedFields) => {
                        // Aquí puedes manejar la lógica para actualizar los campos del formulario
                        console.log(updatedFields);
                    }}
                />
            </div>
        </div>
    );
};

export default DynamicForm;
