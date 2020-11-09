import React from 'react';

const Logo = (props) => {
  return (
    <img
      alt="Logo"
      src="/static/cloudpluslogo.svg"
      {...props}
    />
  );
};

export default Logo;
