import { useEffect } from "react";
import { Button } from "reactstrap";

const FormButton = ({ name }) => {
  useEffect(() => {
    console.log(name);
  }, [name]);

  return (
    <>
      <Button style={{ height: "20px", width: "100px" }}>{name}</Button>
    </>
  );
};

export default FormButton;
