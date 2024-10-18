import { Card } from "reactstrap";
import { useEffect, useState } from "react";
import { GetForms } from "../../service/FormsService";
import ListButtons from "./components/list_buttons";

export default function FormsPage(){
    const [forms, setForms] = useState([])

    useEffect(() => {
        console.log(GetForms())
        setForms(GetForms())
    }, [])


    return (
        <>
        <Card style={{ height: "400px", width: "400px" }}><ListButtons forms = {forms}/></Card>
        </>
    );
}
