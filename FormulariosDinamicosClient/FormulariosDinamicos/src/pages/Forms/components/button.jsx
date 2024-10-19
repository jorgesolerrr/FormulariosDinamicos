/* eslint-disable react/prop-types */
import { useEffect } from "react";
import { Button } from "reactstrap";

const FormButton = ({ index, name, onClick }) => {
    useEffect(() => {
        console.log(name);
    }, [name]);

    return (
        <>
            <Button
                style={{
                    height: "40px",
                    width: "150px",
                    padding: "10px",
                    fontSize: "16px",
                    overflow: "hidden",
                    textOverflow: "ellipsis",
                    whiteSpace: "nowrap",
                }}
                onClick={() => {
                  onClick(index)}}
            >
                {name}
            </Button>
        </>
    );
};

export default FormButton;
