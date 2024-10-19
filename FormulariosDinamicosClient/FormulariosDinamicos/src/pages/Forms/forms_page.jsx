import { Card } from "reactstrap";
import { useEffect, useState } from "react";
import { GetForms } from "../../service/FormsService";
import ListButtons from "./components/list_buttons";
import DynamicForm from "./components/form";

export default function FormsPage() {
    const [forms, setForms] = useState([]);
    const [selectedForm, setSelectedForm] = useState(null);

    useEffect(() => {
        const fetchForms = async () => {
            const formsData = await GetForms();
            setForms(formsData.data);
        };

        fetchForms();
    }, []);

    const handleButtonClick = (index) => {
        console.log("TOQUE EL BOTON")
        setSelectedForm(index);
    };

    

    return (
        <>
            <Card style={{ height: "300px", width: "400px" }}>
                { selectedForm !== null ? (
                    console.log(forms[selectedForm]),
                    <DynamicForm currentForm={forms[selectedForm]} />
                ) : (
                    <h3>Select a form</h3>
                )
                }
                <ListButtons forms={forms} onButtonClick={handleButtonClick}/>
            </Card>
        </>
    );
}
