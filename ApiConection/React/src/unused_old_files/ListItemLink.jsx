import React from "react";
import {
  ListItem,
  ListItemIcon,
  ListItemText,
  Tooltip
} from "@material-ui/core";

import {
  Link as RouterLink
} from "react-router-dom";

function ListItemLink(props) {
  const { icon, primary, to, onClick } = props;

  const renderLink = React.useMemo(
    () =>
      React.forwardRef((itemProps, ref) => (
        <RouterLink to={to} ref={ref} {...itemProps} />
      )),
    [to]
  );

  return (
    <Tooltip title={primary} placement="right" arrow>
      <ListItem button component={renderLink} onClick={onClick}>
        {icon ? <ListItemIcon>{icon}</ListItemIcon> : null}
        <ListItemText primary={primary} />
      </ListItem>
    </Tooltip>
  );
}

export default ListItemLink;
