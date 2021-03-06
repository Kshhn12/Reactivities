import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

export const LoadingComponent: React.FC<{inverted?: boolean; content?: string;}> = ({
     inverted = true, //false = dark background, true = light background
     content 
    }) => {
  return (
    <Dimmer active inverted={inverted}>
      <Loader content={content} />
    </Dimmer>
  );
};
