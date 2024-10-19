/* eslint-disable react/prop-types */
import { Card, Row } from "reactstrap";
import FormButton from "./button";
import { useEffect, useState } from "react";
import PropTypes from "prop-types";

const ListButtons = ({ forms, onButtonClick }) => {
    const [formNull, setFormNull] = useState([]);

    useEffect(() => {
        if (forms !== null) {
            setFormNull(forms);
        }
    }, [forms]);

    return (
        <Card
            style={{ height: "auto", width: "auto" }}
            className="ml-5 mr-5 mt-5 mb-5"
        >
            <Row
                style={{
                    display: "flex",
                    flexDirection: "row",
                    flexWrap: "wrap",
                    bottom: 0,
                    justifyContent: 'center', alignItems: 'center'
                }}
            >
                {formNull !== null ? (
                    formNull.map((item, index) => (
                        <div key={index} style={{ margin: "5px" }}>
                            <FormButton
                                index={index}
                                name={item.name}
                                onClick={onButtonClick}
                            />
                        </div>
                    ))
                ) : (
                    <></>
                )}
            </Row>
        </Card>
    );
};
ListButtons.propTypes = {
    forms: PropTypes.array,
};

export default ListButtons;
