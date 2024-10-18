import { Card, Row, Col } from "reactstrap";
import FormButton from "./button";
import { useEffect, useState } from "react";

const ListButtons = ({ forms }) => {
  const [formNull, setFormNull] = useState([]);

  useEffect(() => {
    if (forms !== null) {
      setFormNull(forms);
    }
  }, [forms]);

  return (
    <Card
      style={{ height: "200px", width: "200px" }}
      className="ml-5 mr-5 mt-5 mb-5"
    >
      <Col>
        {formNull !== null ? (
          formNull.map((item, index) => (
            <div key={index} style={{ margin: "5px" }}>
              <FormButton name={item.name} />
            </div>
          ))
        ) : (
          <></>
        )}
        <div style={{ margin: "5px" }}>
          <FormButton name="Otro" />
        </div>
      </Col>
    </Card>
  );
};

export default ListButtons;
