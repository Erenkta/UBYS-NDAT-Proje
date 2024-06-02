import { useTheme } from "@mui/material/styles";
import { Box, Typography, Avatar } from "@mui/material";

import Avatar1 from "assets/avatar1";

const GenelBilgiler = ({ details }) => {
  const theme = useTheme();

  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
      }}
    >
      <Box
        sx={{
          paddingY: 2,
          paddingLeft: 3,
          width: "100%",
          display: "flex",
          alignItems: "flex-start",
          flexDirection: "column",
        }}
      >
        <Typography variant="subtitle2">{`Ders Adı: ${details.courseName}`}</Typography>
        <Typography variant="subtitle2">{` ${details.courseContent}`}</Typography>
      </Box>
      <Box
        sx={{
          display: "grid",
          alignItems: "center",
          height: "40px",
          paddingLeft: 3,
          gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr",
          backgroundColor: theme.palette.grey[200],
          borderTop: `1px solid ${theme.palette.divider}`,
          borderBottom: `1px solid ${theme.palette.divider}`,
        }}
      >
        <Typography variant="caption">Sınav Tipi</Typography>
        <Typography variant="caption">Sınav Tipi</Typography>
        <Typography variant="caption">Sınav Tipi</Typography>
        <Typography variant="caption">Sınav Tipi</Typography>
        <Typography variant="caption">Sınav Tipi</Typography>
      </Box>
      <Box
        sx={{
          width: "100%",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          paddingY: 3,
          borderBottom: `1px solid ${theme.palette.divider}`,
        }}
      >
        <Box
          sx={{
            width: "100%",
            display: "flex",
            alignItems: "center",
            justifyContent: "space-around",
          }}
        >
          <Typography color="error" variant="caption">
            Dersinize ait genel bilgiler bulunmamaktadır.
          </Typography>
        </Box>
      </Box>
      <Box
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            marginLeft: 3,

            marginY: 3,
          }}
        >
          <Avatar src={""} />
          <Typography
            sx={{
              marginLeft: 3,
            }}
            variant="caption"
          >
            Dersi Veren: John Doe
          </Typography>
        </Box>
        <Box pr={3}>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <Typography
              variant="caption"
              sx={{
                marginRight: 1,
              }}
            >
              Final Sonunda Oluşan Sınıf Ağırlıklı Not Ortalaması:{" "}
            </Typography>
            <Typography>-</Typography>
          </Box>
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
            }}
          >
            <Typography
              variant="caption"
              sx={{
                marginRight: 1,
              }}
            >
              Bütünleme Sonunda Oluşan Sınıf Ağırlıklı Not Ortalaması:{" "}
            </Typography>
            <Typography>-</Typography>
          </Box>
        </Box>
      </Box>
    </Box>
  );
};
export default GenelBilgiler;
